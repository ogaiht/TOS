import { CollectionHelper } from '../common/collections/collection.helper';
import { Action, constr, Func, Predicate } from '../common/common.types';
import { ICollectionItem } from './database';
import { IIdGenerator } from './id.generator';

export interface ICollection<TItem extends ICollectionItem<TId>, TId> {
    add(item: TItem): TId;
    addAsync(item: TItem): Promise<TId>;
    delete(where: Predicate<TItem>): number;
    deleteAsync(where: Predicate<TItem>): Promise<number>;
    deleteById(id: TId): boolean;
    deleteByIdAsync(id: TId): Promise<boolean>;
    find(where: Predicate<TItem>): TItem[];
    findAsync(where: Predicate<TItem>): Promise<TItem[]>;
    findById(id: TId): TItem | undefined;
    findByIdAsync(id: TId): Promise<TItem | undefined>;
    update(item: TItem): void;
    updateAsync(item: TItem): Promise<void>;
}

export class Collection<TItem extends ICollectionItem<TId>, TId> implements ICollection<TItem, TId> {

    constructor(
        private readonly idGenerator: IIdGenerator<TId>,
        private readonly collectionMap: Map<TId, TItem>
        ) { }

    public add(item: TItem): TId {
        const id: TId = this.idGenerator.next();
        this.collectionMap.set(id, item);
        item.id = id;
        return id;
    }

    public deleteById(id: TId): boolean {
        return this.collectionMap.delete(id);
    }

    public delete(where: Predicate<TItem>): number {
        return CollectionHelper.remove(this.collectionMap, (entry: [TId, TItem]) => where(entry[1]));
    }

    public find(where: Predicate<TItem>): TItem[] {
        return CollectionHelper.where(this.collectionMap, (entry:[TId, TItem]) => where(entry[1])).map((entry:[TId, TItem]) => entry[1]);
    }

    public findById(id: TId): TItem | undefined {
        console.log('findById: ', id, ', collection: ', this.collectionMap);
        const item: TItem | undefined = this.collectionMap.get(id);
        console.log('found: ', item);
        return item;
        //return this.collectionMap.get(id);
    }

    public update(item: TItem): void {
        const id: TId = item.id;
        if (!this.collectionMap.has(id)) {
            throw new Error(`Item not found for id '${id}'.`);
        }
        this.collectionMap.set(id, item);
    }

    public addAsync(item: TItem): Promise<TId> {
        return Collection.executeWithResult(() => this.add(item));
    }

    public deleteAsync(where: Predicate<TItem>): Promise<number> {
        return Collection.executeWithResult(() => this.delete(where));
    }

    public deleteByIdAsync(id: TId): Promise<boolean> {
        return Collection.executeWithResult(() => this.collectionMap.delete(id));
    }

    public findAsync(where: Predicate<TItem>): Promise<TItem[]> {
        return Collection.executeWithResult(() => this.find(where));
    }

    public findByIdAsync(id: TId): Promise<TItem | undefined> {
        return Collection.executeWithResult<TItem | undefined> (() => this.findById(id));
    }

    public updateAsync(item: TItem): Promise<void> {
        return Collection.executeWithoutResult(() => this.update(item));
    }

    private static executeWithResult<TResult>(execution: Func<TResult>): Promise<TResult> {
        return new Promise((resolve, reject) => {
            try {
                const result: TResult = execution();
                resolve(result);
            } catch (error) {
                reject(error);
            }
        });
    }

    private static executeWithoutResult(action: Action): Promise<void> {
        return new Promise((resolve, reject) => {
            try {
                action();
                resolve();
            } catch (error) {
                reject(error);
            }
        });
    }
}

class PropertyIndex<TDocument, TId, TValue> {
    private readonly index: Map<TValue, Set<TId>> = new Map();

    add(value:TValue, id:TId): void {
        let set: Set<TId> | undefined = this.index.get(value);
        if (!set) {
            set = new Set<TId>();
            this.index.set(value, set);
        }
        set.add(id);
    }
}

class Condition<TItem, TProperty extends keyof TItem> {
    constructor(
        public readonly type: constr<TItem>,
        public readonly property: TProperty
        ) { }
}

class EqualCondition<TItem, TProperty extends keyof TItem> extends Condition<TItem, TProperty> {
    public readonly condition: ConditionDefinition = ConditionDefinition.EQUAL;
    constructor(
        type: constr<TItem>,
        property: TProperty,
        public readonly value: any
    ) {
        super(type, property);
    }
}

export class User {
    constructor(
        public readonly name: string,
        public readonly email: string
    ) {
    }
}

enum ConditionDefinition {
    EQUAL,
    GREATER,
    SMALLER
}

class GroupCondition {
    
}

const condition: EqualCondition<User, 'name'> = new EqualCondition(User, 'name', 'Thiago');
