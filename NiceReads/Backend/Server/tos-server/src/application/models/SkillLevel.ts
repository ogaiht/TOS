import { Document } from './Document';
import { Uuid } from '../../common/uuid';
import { IEqualible } from '../../common/IEqualible';
import { IHashCodable } from '../../common/IHashCodable';
import { StringUtils } from '../../common/StringUtils';

export class SkillLevel extends Document implements IEqualible, IHashCodable {
    constructor(
        public name: string = '',
        public description: string ='',
        public order: number = -1,
        id: Uuid = Uuid.EMPTY
    ) {
        super(id);
    }

    equals(obj: any): boolean {
        const skillLevel: SkillLevel = obj as SkillLevel;
        return !!skillLevel && skillLevel.name === this.name;
    }

    getHashCode(): number {
        if (StringUtils.isEmptyOrWhiteSpace(this.name)) {
            return 0;
        }
        return StringUtils.hashCode(this.name);
    }
}