import { Uuid } from '../../common/uuid';
import { ICollectionItem } from '../../database/database';

export abstract class Document implements ICollectionItem<Uuid> {
    constructor(public id: Uuid = Uuid.EMPTY) { }
}