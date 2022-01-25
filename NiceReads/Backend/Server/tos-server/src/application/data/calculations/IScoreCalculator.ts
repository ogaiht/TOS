import { Uuid } from '../../../common/uuid';
import { SkillMatchingScore } from './SkillMatchingScore';

export interface IScoreCalculator {
    calculate(
        employeeSkills: Map<Uuid, Uuid>,
        roleSkills: Map<Uuid, Uuid>,
        skillLevels: Map<Uuid, number>): SkillMatchingScore;
}