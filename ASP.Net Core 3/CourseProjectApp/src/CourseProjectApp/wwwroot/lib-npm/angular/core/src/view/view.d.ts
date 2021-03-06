import { ArgumentType, NodeDef, RootData, ViewData, ViewDefinition, ViewFlags, ViewUpdateFn } from './types';
export declare function viewDef(flags: ViewFlags, nodes: NodeDef[], updateDirectives?: ViewUpdateFn, updateRenderer?: ViewUpdateFn): ViewDefinition;
export declare function createEmbeddedView(parent: ViewData, anchorDef: NodeDef, context?: any): ViewData;
export declare function createRootView(root: RootData, def: ViewDefinition, context?: any): ViewData;
export declare function checkNoChangesView(view: ViewData): void;
export declare function checkAndUpdateView(view: ViewData): void;
export declare function checkAndUpdateNode(view: ViewData, nodeDef: NodeDef, argStyle: ArgumentType, v0?: any, v1?: any, v2?: any, v3?: any, v4?: any, v5?: any, v6?: any, v7?: any, v8?: any, v9?: any): boolean;
export declare function checkNoChangesNode(view: ViewData, nodeDef: NodeDef, argStyle: ArgumentType, v0?: any, v1?: any, v2?: any, v3?: any, v4?: any, v5?: any, v6?: any, v7?: any, v8?: any, v9?: any): any;
export declare function destroyView(view: ViewData): void;
