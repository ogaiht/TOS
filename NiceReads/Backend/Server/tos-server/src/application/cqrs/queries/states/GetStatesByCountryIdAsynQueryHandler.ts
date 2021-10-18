import { inject, injectable } from 'inversify';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';
import { Types } from '../../../../types';
import { IStateRepository } from '../../../data/repositories/IStateRepository';
import { State } from '../../../models/State';
import { GetStatesByCountryIdAsyncQuery } from './GetStatesByCountryIdAsynQuery';

@injectable()
export class GetStatesByCountryIdAsynQueryHandler implements AsyncQueryHandler<GetStatesByCountryIdAsyncQuery,  State[]> {

    constructor(@inject(Types.Repositories.STATE_REPOSITORY) private readonly stateRepository: IStateRepository) { }

    async executeAsync(asyncQuery: GetStatesByCountryIdAsyncQuery): Promise<State[]> {
        return await this.stateRepository.findByCountryIdAsync(asyncQuery.countryId);
    }
}