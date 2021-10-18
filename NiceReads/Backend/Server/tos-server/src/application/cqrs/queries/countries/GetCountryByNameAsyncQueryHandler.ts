import { inject, injectable } from 'inversify';
import { Types } from '../../../../types';
import { Country } from '../../../models/Country';
import { GetCountryByNameAsyncQuery } from './GetCountryByNameAsyncQuery';
import { ICountryRepository } from '../../../data/repositories/ICountryRepository';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';

@injectable()
export class GetCountryByNameAsyncQueryHandler implements AsyncQueryHandler<GetCountryByNameAsyncQuery, Country[]> {

    constructor(@inject(Types.Repositories.COUNTRY_REPOSITORY) private readonly countryRepository: ICountryRepository) { }

    async executeAsync(query: GetCountryByNameAsyncQuery): Promise<Country[]> {
        return await this.countryRepository.findByNameAsync(query.countryName);
    }
}