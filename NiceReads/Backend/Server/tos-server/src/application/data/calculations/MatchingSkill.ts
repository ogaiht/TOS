import { Uuid } from '../../../common/uuid';

export class MatchingSkill
{
    constructor(
        public readonly skillId: Uuid,
        public readonly employeeLevelId: Uuid,
        public readonly roleLevelId: Uuid)
    { }
}