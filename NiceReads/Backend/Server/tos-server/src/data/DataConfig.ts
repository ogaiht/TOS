import { Container, inject, injectable } from 'inversify';
import { Uuid } from '../common/uuid';
import { Database, IDatabase } from '../database/database';
import { IIdGenerator, UuidIdGenerator } from '../database/id.generator';
import { Types } from '../types';

@injectable()
class UuidDatabase extends Database<Uuid> {
    constructor(@inject(Types.UUID_GENERATOR) idGenerator: IIdGenerator<Uuid>) {
        super(idGenerator);
    }
 }


export function configDataObjects(container: Container): void {
    container.bind<IDatabase<Uuid>>(Types.DATABASE).toConstantValue(new UuidDatabase(new UuidIdGenerator()));
    container.bind<IIdGenerator<Uuid>>(Types.UUID_GENERATOR).to(UuidIdGenerator);
}