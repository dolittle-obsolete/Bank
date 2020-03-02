import { Disposable, ICollectionObserverSplice } from 'aurelia-binding';
import { CollectionObserver } from 'aurelia-framework';
import { ArrayRepeatStrategy, Repeat, RepeatStrategy } from 'aurelia-templating-resources';

class RXObservableCollectionObserver {
    subscribe(context: any, callable: any) {
        callable.items.subscribe((items: any) => {
            callable[context](items, items);
        });
    }

    unsubscribe(context: any, callable: any) {
    }

    addChangeRecord(changeRecord: any) {
        debugger;

    }
}

// tslint:disable-next-line: max-classes-per-file
export class RXObservablesRepeatStrategy implements RepeatStrategy {
    private _innerStrategy: ArrayRepeatStrategy;

    constructor() {
        this._innerStrategy = new ArrayRepeatStrategy();
    }

    instanceChanged(repeat: Repeat, items: any): void {
        //this._innerStrategy.instanceChanged(repeat, items.value);
    }

    instanceMutated(repeat: Repeat, items: any, changes: any): void {
        //changes.forEach((_: any) => _.removed = []);
        //this._innerStrategy.instanceMutated(repeat, items.value, changes);
    }

    getCollectionObserver(observerLocator: any, items: any) {
        const observer = new RXObservableCollectionObserver();
        return observer;
        //const observer = observerLocator.getArrayObserver(items.value);
        //const o = observerLocator.getObserver(items, 'value');
        //return observer;
    }
}
