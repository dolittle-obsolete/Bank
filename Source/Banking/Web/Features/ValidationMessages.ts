import {
    autoinject,
    Binding,
    BoundViewFactory,
    customAttribute,
    TargetInstruction,
    templateController,
    View,
    ViewSlot
} from 'aurelia-framework';

import {
    AbstractRepeater,
    RepeatStrategyLocator,
    viewsRequireLifecycle
} from 'aurelia-templating-resources';

@autoinject
@customAttribute('validation-messages')
@templateController
export class ValidationMessages extends AbstractRepeater {
    scope: any;
    items: any;
    matcherBinding: any;
    strategy: any;
    private _itemsBinding: Binding;

    constructor(
        private _viewFactory: BoundViewFactory,
        _instruction: TargetInstruction,
        private _viewSlot: ViewSlot,
        private _strategyLocator: RepeatStrategyLocator) {
        super({
            local: 'component',
            viewsRequireLifecycle: viewsRequireLifecycle(_viewFactory)
        });

        const instructions = _instruction.behaviorInstructions.filter(_ => _.attrName === 'validation-messages');
        this._itemsBinding = (instructions[0].attributes as any).items as Binding;
    }

    /** @inheritdoc */
    bind(bindingContext: any, overrideContext: any) {
        this.scope = { bindingContext, overrideContext };
        this.items = ['hello', 'world'];
        this.itemsChanged();
    }

    /** @inheritdoc */
    unbind() {
        this.scope = null;
    }

    createView() {
        const view: View = this._viewFactory.create();
        return view;
    }

    itemsChanged() {
        const items = this.items;
        this.strategy = this._strategyLocator.getStrategy(items);
        this.strategy.instanceChanged(this, items);
    }

    // @override AbstractRepeater

    /** @inheritdoc */
    viewCount() { return (this._viewSlot as any).children.length; }

    /** @inheritdoc */
    views() { return (this._viewSlot as any).children; }

    /** @inheritdoc */
    view(index: number) { return (this._viewSlot as any).children[index]; }

    /** @inheritdoc */
    matcher() {
        return this.matcherBinding ?
            this.matcherBinding.sourceExpression.evaluate(this.scope, this.matcherBinding.lookupFunctions) : null;
    }

    /** @inheritdoc */
    addView(bindingContext: any, overrideContext: any) {
        const view = this.createView();
        view.bind(bindingContext, overrideContext);
        this._viewSlot.add(view);
    }

    /** @inheritdoc */
    insertView(index: number, bindingContext: any, overrideContext: any) {

        const view = this.createView();
        view.bind(bindingContext, overrideContext);
        this._viewSlot.insert(index, view);
    }

    /** @inheritdoc */
    moveView(sourceIndex: number, targetIndex: number) {
        this._viewSlot.move(sourceIndex, targetIndex);
    }

    /** @inheritdoc */
    removeAllViews(returnToCache: any, skipAnimation: any) {
        return this._viewSlot.removeAll(returnToCache, skipAnimation);
    }

    /** @inheritdoc */
    removeViews(viewsToRemove: any, returnToCache: any, skipAnimation: any) {
        return this._viewSlot.removeMany(viewsToRemove, returnToCache, skipAnimation);
    }

    /** @inheritdoc */
    removeView(index: number, returnToCache: any, skipAnimation: any) {
        return this._viewSlot.removeAt(index, returnToCache, skipAnimation);
    }

    /** @inheritdoc */
    // tslint:disable-next-line: no-empty
    updateBindings(view: any) {
    }
}
