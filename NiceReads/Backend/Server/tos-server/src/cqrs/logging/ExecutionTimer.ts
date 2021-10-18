import { IExecutionTimer } from './IExecutionTimer';

export class ExecutionTimer implements IExecutionTimer {

    private readonly startTime: number;

    constructor() {
        this.startTime = Date.now();
    }

    stop(): void {
        const endTime:Number = Date.now();
    }
}