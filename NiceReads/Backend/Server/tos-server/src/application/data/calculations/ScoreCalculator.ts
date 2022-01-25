import { injectable } from 'inversify';
import { Uuid } from '../../../common/uuid';
import { IScoreCalculator } from './IScoreCalculator';
import { MatchingSkill } from './MatchingSkill';
import { SkillMatchingScore } from './SkillMatchingScore';

@injectable()
export class ScoreCalculator implements IScoreCalculator {
        public calculate(
            employeeSkills: Map<Uuid, Uuid>,
            roleSkills: Map<Uuid, Uuid>,
            skillLevels: Map<Uuid, number>): SkillMatchingScore
        {
            if (roleSkills.size === 0) {
                return new SkillMatchingScore(0, []);
            }
            const matchingSkills: MatchingSkill[] = [];
            for (const roleSkill of roleSkills) {
                if (employeeSkills.has(roleSkill[0])) {
                    const employeeSkillLevel: Uuid | undefined = employeeSkills.get(roleSkill[0]);
                    if (employeeSkillLevel) {
                        const employeeLevel: number | undefined = skillLevels.get(employeeSkillLevel);
                        const roleLevel: number | undefined = skillLevels.get(roleSkill[1]);
                        if (employeeLevel && roleLevel && employeeLevel >= roleLevel) {
                            matchingSkills.push(new MatchingSkill(roleSkill[0], employeeSkillLevel, roleSkill[1]));
                        }
                    }
                }
            }
            const score: number = matchingSkills.length / roleSkills.size;
            return new SkillMatchingScore(score, matchingSkills);
        }
    }