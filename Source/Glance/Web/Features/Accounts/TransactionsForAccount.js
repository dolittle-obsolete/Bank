/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class TransactionsForAccount extends Query
{
    constructor() {
        super();
        this.nameOfQuery = 'TransactionsForAccount';
        this.generatedFrom = 'Read.Accounts.TransactionsForAccount';

        this.accountId = '00000000-0000-0000-0000-000000000000';
    }
}