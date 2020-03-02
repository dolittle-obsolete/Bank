// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Command } from '@dolittle/commands';
import { Expression } from 'aurelia-binding';
import { autoinject, Binding, BindingEngine, View, viewEngineHooks } from 'aurelia-framework';

class ValidationContextImplementation {
    isValid: boolean = true;

    constructor() {
        setInterval(() => this.isValid = this.isValid !== true, 1000);
    }
}

// tslint:disable-next-line: max-classes-per-file
@autoinject
@viewEngineHooks
export class ValidationContext {

    constructor(private _bindingEngine: BindingEngine) {
    }

    beforeBind(view: View) {
        if ((view as any).hasOwnProperty('bindings')) {
            const bindings = (view as any).bindings as Binding[];
            if (bindings.length > 0) {
                bindings.forEach((binding) => {
                    if (binding.sourceExpression) {
                        const expression: Expression = binding.sourceExpression;
                        const expressionPath = expression.getPath();

                        if (expressionPath.length > 0) {
                            let isCommandBinding = false;
                            let currentScope = view.bindingContext as any;
                            expressionPath.forEach((member) => {
                                if (!currentScope.hasOwnProperty(member)) {
                                    return;
                                }

                                if (currentScope[member] instanceof Command) {
                                    isCommandBinding = true;
                                    return;
                                }

                                currentScope = currentScope[member];
                            });

                            if (isCommandBinding) {
                                const fullPath = expressionPath.join('.');

                                let currentScope = view.bindingContext as any;
                                expressionPath.forEach((member) => {
                                    const observer = this._bindingEngine.propertyObserver(currentScope, member);

                                    currentScope = currentScope[member];
                                });
                            }
                        }
                    }
                });
            }
        }

        const context = view.overrideContext as any;
        context.validationContext = new ValidationContextImplementation();
    }
}
