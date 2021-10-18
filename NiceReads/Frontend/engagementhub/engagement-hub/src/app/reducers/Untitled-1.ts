export type AbstractComponent<T> = Function & { prototype: T };
export type constr<T> = AbstractComponent<T> | { new(...args: unknown[]): T };
export type Nullable<T> = T | null | undefined;
export type NullOrUndefined = null | undefined;
export type Predicate<T> = (item: T) => boolean;

export interface IEntity<TId> {
    id: TId;
}

export interface IRepository<TEntity extends IEntity<TId>, TId> {
    add(entity: TEntity): TId;
    update(entity: TEntity): boolean;
    delete(id: TId): boolean;
}

export class Repository<TEntity extends IEntity<TId>, TId> implements IRepository<TEntity, TId> {

    protected readonly collection: ICollection<TEntity, TId>;
    constructor(
        protected readonly typeConstr: constr<TEntity>,
        protected readonly database: IDatabase<TId>) {
            this.collection = this.database.getCollection(typeConstr);
        }

    public add(entity: TEntity): TId {
        return this.collection.add(entity);
    }

    public update(entity: TEntity): boolean {
        return this.collection.update((e: TEntity) => e.id === entity.id, entity);
    }

    public delete(id: TId): boolean {
        return this.collection.delete((e: TEntity) => e.id === id) === 1;
    }
}


export interface IDatabase<TId> {
    getCollection<TDocument>(constr: constr<TDocument>): ICollection<TDocument, TId>;
}

export class Database<TId> {
    private readonly collections: Map<any, Map<any, any>> = new Map<any, Map<any, any>>();
    private readonly idGenerator: IIdGenerator<TId>;

    public getCollection<TDocument>(constr: constr<TDocument>): ICollection<TDocument, TId> {
        let collection: Map<TId, TDocument> = null;
        if (!this.collections.has(constr)) {
            collection = new Map<TId, TDocument>();
            this.collections.set(constr, collection);
        } else {
            collection = this.collections.get(constr);
        }
        return new Collection<TDocument, TId>(this.idGenerator, collection);
    }
}

export interface IIdGenerator<TId> {
    next(): TId;
}

export interface ICollection<TDocument, TId> {
    add(item: TDocument): TId;
    update(where: Predicate<TDocument>, item: TDocument): boolean;
    delete(where: Predicate<TDocument>): number;
    find(where: Predicate<TDocument>): TDocument[];
}

export class Collection<TDocument, TId> implements ICollection<TDocument, TId> {

    constructor(
        private readonly idGenerator: IIdGenerator<TId>,
        private readonly collectionMap: Map<TId, TDocument>
        ) { }

    public add(item: TDocument): TId {
        const id: TId = this.idGenerator.next();
        this.collectionMap.set(id, item);
        return id;
    }

    public update(where: Predicate<TDocument>, item: TDocument): boolean {
        let selectedEntry: [TId, TDocument] = null;
        for(const entry of this.collectionMap.entries()) {
            if (where(entry[1])) {
                selectedEntry = entry;
                break;
            }
        }
        if (!!selectedEntry) {
            this.collectionMap.set(selectedEntry[0], item);
            return true;
        }
        return false;
    }

    public delete(where: Predicate<TDocument>): number {
        return CollectionUtils.remove(this.collectionMap, (entry: [TId, TDocument]) => where(entry[1]));
    }

    public find(where: Predicate<TDocument>): TDocument[] {
        return CollectionUtils.where(this.collectionMap, (entry:[TId, TDocument]) => where(entry[1])).map((entry:[TId, TDocument]) => entry[1]);
    }
}

export class CollectionUtils {
    public static where<TKey, TValue>(collection: Map<TKey, TValue>, where: Predicate<[TKey, TValue]>): [TKey, TValue][] {
        const selectedEntries: [TKey, TValue][] = [];
        for(const entry of collection.entries()) {
            if (where(entry)) {
                selectedEntries.push(entry);
            }
        }
        return selectedEntries;
    }

    public static remove<TKey, TValue>(collection: Map<TKey, TValue>, where: Predicate<[TKey, TValue]>): number {
        const items:[TKey, TValue][] = CollectionUtils.where(collection, (entry: [TKey, TValue]) => where(entry));
        let removedItemsCount = 0;
        for (const entry of items) {
            if (collection.delete(entry[0])) {
                removedItemsCount++;
            }
        }
        return removedItemsCount;
    }
}


export class Entity<TId> implements IEntity<TId> {
    public id: TId;
}

export class User extends Entity<string> {
    public name: string;
    public email: string;
}

export interface IUserRepository extends IRepository<User, string> {
    findByName(name: string): User[];
}

export class UserRepository extends Repository<User, string> implements IUserRepository {

    constructor(database: IDatabase<string>) {
        super(User, database);
    }

    public findByName(name: string): User[] {
        return this.collection.find((user: User) => user.name.startsWith(name));
    }
}