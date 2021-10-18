import { inject, injectable } from 'inversify';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';
import { Types } from '../../../../types';
import { IStateRepository } from '../../../data/repositories/IStateRepository';
import { State } from '../../../models/State';
import { GetStatesByNameAsyncQuery } from './GetStatesByNameAsyncQuery';

@injectable()
export class GetStatesByNameAsyncQueryHandler extends AsyncQueryHandler<GetStatesByNameAsyncQuery, State[]> {

    constructor(@inject(Types.Repositories.STATE_REPOSITORY) private readonly stateRepository: IStateRepository) {
        super();
    }

    async executeAsync(asyncQuery: GetStatesByNameAsyncQuery): Promise<State[]> {
        return await this.stateRepository.findByNameAsync(asyncQuery.stateName);
    }
}