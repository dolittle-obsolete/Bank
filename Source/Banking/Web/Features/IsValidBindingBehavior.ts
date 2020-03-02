// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { bindingBehavior, bindingMode } from 'aurelia-binding';

function isValid(this: any, newValue: any) {
    let result = true;
    if (newValue !== '00000000-0000-0000-0000-000000000000') {
        result = false;
    }
    this.originalUpdateTarget(result);
}

@bindingBehavior('isvalid')
export class IsValidBindinBehavior {
    bind(binding: any, scope: any) {
        binding.mode = bindingMode.toView;
        const currentMethod = binding.updateTarget;
        binding.updateTarget = isValid;
        binding.originalUpdateTarget = currentMethod;
    }

    unbind(binding: any, scope: any) {
        binding.updateTarget = binding.originalUpdateTarget;
    }
}
