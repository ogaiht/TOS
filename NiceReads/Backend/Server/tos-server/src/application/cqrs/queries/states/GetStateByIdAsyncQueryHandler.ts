import { inject, injectable } from 'inversify';
import { AsyncQueryHandler } from '../../../../cqrs/handlers/queries/AsyncQueryHandler';
import { Types } from '../../../../types';
import { IStateRepository } from '../../../data/repositories/IStateRepository';
import { State } from '../../../models/State';
import { GetStateByIdAsyncQuery } from './GetStateByIdAsyncQuery';

@injectable()
export class GetStateByIdAsyncQueryHandler extends AsyncQueryHandler<GetStateByIdAsyncQuery, State | undefined> {
    constructor(@inject(Types.Repositories.STATE_REPOSITORY) private readonly stateRepository: IStateRepository) {
        super();
    }
    async executeAsync(asyncQuery: GetStateByIdAsyncQuery): Promise<State | undefined> {
        return await this.stateRepository.findAsync(asyncQuery.stateId);
    }
}