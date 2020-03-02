// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { autoinject } from 'aurelia-dependency-injection';

import { TransferMoneyFromDebitAccount } from './Accounts/TransferMoneyFromDebitAccount';

import { BehaviorSubject, interval, Observable, pipe } from 'rxjs';
import { filter, map } from 'rxjs/operators';

function discardOddDoubleEven() {
    return pipe(
        filter((v: number) => !(v % 2)),
        map((v: number) => v + v),
    );
}

// tslint:disable-next-line: max-classes-per-file
@autoinject
export class Index {
    something: string = 'Hello world';
    counter: number = 0;
    nested: any = {
        command: new TransferMoneyFromDebitAccount()
    };

    observable: BehaviorSubject<number>;
    timed: Observable<number>;
    filtered: Observable<number>;
    isValid: BehaviorSubject<boolean>;
    observableArray: BehaviorSubject<number[]>;
    regularArray: number[] = [5, 4, 3, 2, 1];

    constructor() {
        let nn = 0;

        this.observable = new BehaviorSubject(0);

        setInterval(() => this.counter++, 2000);
        this.timed = interval(500);

        this.filtered = discardOddDoubleEven()(this.timed);
        this.isValid = new BehaviorSubject<boolean>(false);

        setInterval(() => {
            this.observable.next(nn++);
        }, 1000);

        let isValid = false;

        setInterval(() => {
            isValid = isValid !== true;
            this.isValid.next(isValid);
        }, 1500);

        let numbers = 0;
        this.observableArray = new BehaviorSubject<number[]>([]);
        const array: number[] = [];
        setInterval(() => {
            array.push(numbers++);
            this.observableArray.next(array);
        }, 2000);

        /*
        setTimeout(() => {
            this.nested = {
                command: new TransferMoneyFromDebitAccount()
            };
        }, 2000);*/
    }
}
