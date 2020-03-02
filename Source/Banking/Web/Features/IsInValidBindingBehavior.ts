// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { bindingBehavior, bindingMode } from 'aurelia-binding';

function isInValid(this: any, newValue: any) {
    let result = false;
    if (newValue !== '00000000-0000-0000-0000-000000000000') {
        result = true;
    }
    this.originalUpdateTarget(result);
}

@bindingBehavior('isinvalid')
export class IsInValidBindingBehavior {
    bind(binding: any) {
        binding.mode = bindingMode.toView;
        const currentMethod = binding.updateTarget;
        binding.updateTarget = isInValid;
        binding.originalUpdateTarget = currentMethod;
    }

    unbind(binding: any) {
        binding.updateTarget = binding.originalUpdateTarget;
    }
}
