import { Uuid } from '../../../common/uuid';
import { Country } from '../../models/Country';
import { IRepository } from '../../../data/repository';

export interface ICountryRepository extends IRepository<Country, Uuid> {
    findByNameAsync(countryName: string): Promise<Country[]>;
}