import { inject, injectable } from 'inversify';
import { constr } from '../../../common/common.types';
import { Uuid } from '../../../common/uuid';
import { IDatabase } from '../../../database/database';
import { Country } from '../../models/Country';
import { Types } from '../../../types';
import { Repository } from '../../../data/repository';
import { ICountryRepository } from './ICountryRepository';

@injectable()
export class CountryRepository extends Repository<Country, Uuid> implements ICountryRepository {

    constructor(@inject(Types.Data.DATABASE) database: IDatabase<Uuid>) {
        super(database);
    }

    protected getEntityType(): constr<Country> {
        return Country;
    }

    async findByNameAsync(countryName: string): Promise<Country[]> {
        return await this.collection.findAsync((c: Country) => c.name.startsWith(countryName));
    }
}