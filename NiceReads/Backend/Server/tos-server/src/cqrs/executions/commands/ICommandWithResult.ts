import { IExecutionRequestWitResult } from '../IExecutionRequestWitResult';
import { ICommand } from './ICommand';

export interface ICommandWithResult<TResult> extends ICommand, IExecutionRequestWitResult<TResult> {

}