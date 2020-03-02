// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Aurelia } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import 'aurelia-polyfills';
import { RepeatStrategyLocator } from 'aurelia-templating-resources';
import environment from './environment';

import './ExpressionExtensions';
import { RXObservablesRepeatStrategy } from './RXObservablesRepeatStrategy';

// tslint:disable-next-line: no-var-requires
require('../Styles/style.scss');

export function configure(aurelia: Aurelia) {
    aurelia.use
        .standardConfiguration()
        .plugin(PLATFORM.moduleName('@dolittle/components.aurelia'));

    aurelia.use.globalResources(PLATFORM.moduleName('ValidationContext'));
    aurelia.use.globalResources(PLATFORM.moduleName('RXObservables'));
    aurelia.use.globalResources(PLATFORM.moduleName('IsValidBindingBehavior'));
    aurelia.use.globalResources(PLATFORM.moduleName('IsInValidBindingBehavior'));
    aurelia.use.globalResources(PLATFORM.moduleName('ValidationMessages'));
    aurelia.use.globalResources(PLATFORM.moduleName('Visibility'));

    const repeatStrategyLocator = aurelia.container.get(RepeatStrategyLocator);
    repeatStrategyLocator.addStrategy(items => {
        return true;
    }, new RXObservablesRepeatStrategy());

    if (environment.debug) {
        aurelia.use.developmentLogging();
    }

    aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('App')));
}
