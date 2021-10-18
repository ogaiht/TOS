import { inject, injectable } from 'inversify';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';
import { Types } from '../../../../types';
import { ICityRepository } from '../../../data/repositories/ICityRepository';
import { City } from '../../../models/City';
import { GetCitiesByNameAsyncQuery } from './GetCitiesByNameAsyncQuery';

@injectable()
export class GetCitiesByNameAsyncQueryHandler implements AsyncQueryHandler<GetCitiesByNameAsyncQuery,  City[]> {

    constructor(@inject(Types.Repositories.CITY_REPOSITORY) private readonly cityRepository: ICityRepository) { }

    async executeAsync(asyncQuery: GetCitiesByNameAsyncQuery): Promise<City[]> {
        return await this.cityRepository.findByNameAsync(asyncQuery.cityName);
    }
}