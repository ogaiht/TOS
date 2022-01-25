import { MatchingSkill } from './MatchingSkill';

export class SkillMatchingScore
{
    constructor(
        public readonly value: number,
        public readonly matchingSkills: MatchingSkill[])
    { }
}