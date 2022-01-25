import { Container } from 'inversify';
import { Types } from '../../types';
import { IScoreCalculator } from './calculations/IScoreCalculator';
import { ScoreCalculator } from './calculations/ScoreCalculator';
import { configRepositories } from './repositories/RepositoriesConfig';

export function configDataDependencies(container: Container): void {
    configRepositories(container);
    container.bind<IScoreCalculator>(Types.SCORE_CALCULATOR).to(ScoreCalculator);
}