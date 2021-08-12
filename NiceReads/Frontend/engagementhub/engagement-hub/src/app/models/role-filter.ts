export interface RoleFilter {
    cityIds?: string[];
    rankIds?: string[];
    name?: string;
    startDate?: Date;
    endDate?: Date;
    weekCommitment?: number;
    skillIds: string[];
}