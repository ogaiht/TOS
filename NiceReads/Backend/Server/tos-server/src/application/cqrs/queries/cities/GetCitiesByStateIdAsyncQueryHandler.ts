import { inject, injectable } from 'inversify';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';
import { Types } from '../../../../types';
import { ICityRepository } from '../../../data/repositories/ICityRepository';
import { City } from '../../../models/City';
import { GetCitiesByStateIdAsyncQuery } from './GetCitiesByStateIdAsyncQuery';

@injectable()
export class GetCitiesByStateIdAsyncQueryHandler implements AsyncQueryHandler<GetCitiesByStateIdAsyncQuery,  City[]> {

    constructor(@inject(Types.Repositories.CITY_REPOSITORY) private readonly cityRepository: ICityRepository) { }

    async executeAsync(asyncQuery: GetCitiesByStateIdAsyncQuery): Promise<City[]> {
        return await this.cityRepository.findByStateIdAsync(asyncQuery.stateId);
    }
}