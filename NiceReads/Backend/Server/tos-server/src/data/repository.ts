import { injectable } from 'inversify';
import { constr } from '../common/common.types';
import { IEntity } from '../common/datamodel/entity';
import { ICollection } from '../database/collection';
import { IDatabase } from '../database/database';

export interface IRepository<TEntity extends IEntity<TId>, TId> {
    add(entity: TEntity): TId;
    addAsync(entity: TEntity): Promise<TId>;
    find(id: TId): TEntity | undefined;
    findAsync(id: TId): Promise<TEntity | undefined>;
    update(entity: TEntity): void;
    updateAsync(entity: TEntity): Promise<void>;
    delete(id: TId): boolean;
    deleteAsync(id: TId): Promise<boolean>;
}

@injectable()
export abstract class Repository<TEntity extends IEntity<TId>, TId> implements IRepository<TEntity, TId> {

    private repositoryCollection: ICollection<TEntity, TId>;

    constructor(protected readonly database: IDatabase<TId>) { }

    protected abstract getEntityType(): constr<TEntity>;

    protected get collection(): ICollection<TEntity, TId> {
        if (!this.repositoryCollection) {
            this.repositoryCollection = this.database.getCollection(this.getEntityType());
        }
        return this.repositoryCollection;
    }

    public add(entity: TEntity): TId {
        return this.collection.add(entity);
    }

    public async addAsync(entity: TEntity): Promise<TId> {
        return await this.collection.addAsync(entity);
    }

    public find(id: TId): TEntity | undefined {
        return this.collection.findById(id);
    }

    public async findAsync(id: TId): Promise<TEntity | undefined> {
        return await this.collection.findByIdAsync(id);
    }

    public update(entity: TEntity): void {
        return this.collection.update(entity);
    }

    public async updateAsync(entity: TEntity): Promise<void> {
        return await this.collection.updateAsync(entity);
    }

    public delete(id: TId): boolean {
        return this.collection.deleteById(id);
    }

    public async deleteAsync(id: TId): Promise<boolean> {
        return await this.collection.deleteByIdAsync(id);
    }
}