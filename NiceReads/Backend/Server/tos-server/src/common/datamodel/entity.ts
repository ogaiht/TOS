import { ICollectionItem } from '../../database/database';

export interface IEntity<TId> extends ICollectionItem<TId> {

}

export class Entity<TId> implements IEntity<TId> {
    constructor(public id: TId) { }
}