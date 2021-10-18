import { injectable } from 'inversify';
import { Uuid } from '../common/uuid';

export interface IIdGenerator<TId> {
    next(): TId;
}

@injectable()
export class UuidIdGenerator implements IIdGenerator<Uuid> {
    next(): Uuid {
        return Uuid.newUuid();
    }
}