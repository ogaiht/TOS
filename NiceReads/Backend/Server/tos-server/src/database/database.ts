import { injectable } from 'inversify';
import { constr } from '../common/common.types';
import { Collection, ICollection } from './collection';
import { IIdGenerator } from './id.generator';

export interface ICollectionItem<TId> {
    id: TId;
}

export interface IDatabase<TId> {
    getCollection<TItem extends ICollectionItem<TId>>(constr: constr<TItem>): ICollection<TItem, TId>;
}

@injectable()
export class Database<TId> {
    private readonly collections: Map<any, Map<TId, ICollectionItem<TId>>> = new Map<any, Map<TId, ICollectionItem<TId>>>();
    constructor(private readonly idGenerator: IIdGenerator<TId>) { }

    public getCollection<TItem extends ICollectionItem<TId>>(constr: constr<TItem>): ICollection<TItem, TId> {
        let collection: Map<TId, TItem> | null = null;
        if (!this.collections.has(constr)) {
            collection = new Map<TId, TItem>();
            this.collections.set(constr, collection);
        } else {
            collection = this.collections.get(constr) as Map<TId, TItem>;
        }
        return new Collection<TItem, TId>(this.idGenerator, collection);
    }
}

