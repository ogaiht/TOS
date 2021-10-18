import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { IDatabase } from '../../../database/database';
import { City } from '../../models/City';
import { Types } from '../../../types';
import { Repository } from '../../../data/repository';
import { ICityRepository } from './ICityRepository';

@injectable()
export class CityRepository extends Repository<City, Uuid> implements ICityRepository {

    constructor(@inject(Types.Data.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }

    protected getEntityType(): constr<City> {
        return City;
    }

    async findByNameAsync(name: string): Promise<City[]> {
        return await this.collection.findAsync((c: City) => c.name.startsWith(name));
    }
    async findByStateIdAsync(statedId: Uuid): Promise<City[]> {
        return await this.collection.findAsync((c: City) => c.stateId === statedId);
    }
}