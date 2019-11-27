/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class Transaction extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '1f00a16e-3f28-4b7f-b7af-821a2864cae1',
           generation: '1'
        };
        this.reason = 0;
        this.amount = 0;
        this.occurred = new Date();
    }
}