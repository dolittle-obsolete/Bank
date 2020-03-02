// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { AccessMember, AccessScope, Expression } from 'aurelia-binding';

declare module 'aurelia-binding' {

    interface Expression {
        getPath(): string[];
    }
}

Expression.prototype.getPath = function() {
    const expressionPath: string[] = [];

    let expression = this;

    while (true) {
        if (expression instanceof AccessMember) {
            expressionPath.unshift((expression as AccessMember).name);
            expression = (expression as AccessMember).object;
        } else if (expression instanceof AccessScope) {
            expressionPath.unshift((expression as AccessScope).name);
            break;
        } else {
            break;
        }
    }

    return expressionPath;
};
