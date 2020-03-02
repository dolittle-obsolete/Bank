import { AccessMember, AccessScope, Expression } from 'aurelia-binding';
import { bindingMode } from 'aurelia-binding';
import { autoinject, Binding, BindingEngine, Scope, View, viewEngineHooks } from 'aurelia-framework';
import { Observable } from 'rxjs';

@autoinject
@viewEngineHooks
export class RXObservables {
    constructor(private _bindingEngine: BindingEngine) {
    }

    beforeBind(view: View) {
        const self = this;
        if ((view as any).hasOwnProperty('bindings')) {
            const bindings = (view as any).bindings as Binding[];
            if (bindings.length > 0) {

                bindings.forEach((binding) => {
                    try {
                        if (binding.sourceExpression) {
                            const expression: Expression = binding.sourceExpression;
                            const expressionPath = expression.getPath();

                            if (expressionPath.length > 0) {
                                let isObservableBinding = false;
                                let currentScope = view.bindingContext as any;
                                expressionPath.forEach((member) => {
                                    if (!currentScope.hasOwnProperty(member)) {
                                        return;
                                    }

                                    if (currentScope[member] instanceof Observable) {
                                        isObservableBinding = true;
                                        return;
                                    }

                                    currentScope = currentScope[member];
                                });

                                if (isObservableBinding) {
                                    const fullPath = expressionPath.join('.');

                                    let currentScope = view.bindingContext as any;
                                    expressionPath.forEach((member) => {
                                        if (currentScope[member] instanceof Observable) {

                                            binding.mode = bindingMode.toView;

                                            function handleValue(newValue: any) {
                                                if (binding.updateTarget) {
                                                    try {
                                                        binding.updateTarget(newValue);
                                                    } catch (ex) {
                                                        binding.bind(view as any as Scope);
                                                        binding.updateTarget(newValue);
                                                    }
                                                }
                                            }
                                            (currentScope[member] as Observable<any>).subscribe(handleValue);
                                        }
                                        currentScope = currentScope[member];
                                    });
                                }
                            }
                        }
                    } catch (ee) {
                        console.log(ee);
                    }
                });
            }
        }
    }
}
