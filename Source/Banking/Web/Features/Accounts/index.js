import { inject } from 'aurelia-framework';
import { OpenAccount } from './OpenAccount';

export class Index {    
    constructor() {
        this.openAccount = new OpenAccount();
    }
}
