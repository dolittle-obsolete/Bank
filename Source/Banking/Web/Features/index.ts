// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { autoinject } from 'aurelia-dependency-injection';

import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

@autoinject
export class Index {
    constructor(private _commandCoordinator: CommandCoordinator, private _queryCoordinator: QueryCoordinator) { }
}
