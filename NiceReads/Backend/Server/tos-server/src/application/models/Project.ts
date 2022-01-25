import { Uuid } from '../../common/uuid';
import { Document } from './Document';
import { Location } from './Location';
import { ProjectStatus } from './ProjectStatus';

export class Project extends Document {
    constructor(
        public name: string  = '',
        public startDate: Date | undefined = undefined,
        public endDate: Date | undefined = undefined,
        public leadId : Uuid | undefined = undefined,
        public roleIds: Uuid[] = [],
        public clientId: Uuid | undefined = undefined,
        public location: Location | undefined = undefined,
        public status: ProjectStatus | undefined = undefined,
        id: Uuid | undefined = undefined
    ) {
        super(id);
    }
}