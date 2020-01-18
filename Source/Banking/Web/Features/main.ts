// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Aurelia } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import 'aurelia-polyfills';
import environment from './environment';

// tslint:disable-next-line: no-var-requires
require('../Styles/style.scss');

export function configure(aurelia: Aurelia) {
    aurelia.use
        .standardConfiguration()
        .plugin(PLATFORM.moduleName('@dolittle/components.aurelia'));

    if (environment.debug) {
        aurelia.use.developmentLogging();
    }

    aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('App')));
}
