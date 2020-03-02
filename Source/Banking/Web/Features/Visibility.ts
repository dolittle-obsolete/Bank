import { inject } from 'aurelia-framework';

@inject(Element)
export class VisibilityCustomAttribute {
    constructor(private _element: HTMLElement) {
    }

    valueChanged(newValue: any) {
        let isVisible = false;

        if (newValue.constructor === Boolean) {
            isVisible = newValue as boolean;
        } else if (newValue === 'true') {
            isVisible = true;
        }
        this._element.style.visibility = isVisible ? 'visible' : 'hidden';
    }
}
