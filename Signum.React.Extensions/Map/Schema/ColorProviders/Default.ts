﻿import * as d3 from 'd3'
import { ClientColorProvider, SchemaMapInfo  } from '../SchemaMap'
import { colorScale, colorScaleSqr  } from '../../Utils'
import { EntityData, EntityKind } from '../../../../../Framework/Signum.React/Scripts/Reflection'
import { MapMessage } from '../../Signum.Entities.Map'

export default function getDefaultProviders(info: SchemaMapInfo): ClientColorProvider[] {

    var namespaceColor = d3.scale.category20();
    var namespace: ClientColorProvider = {
        name: "namespace",
        getFill: t => namespaceColor(t.namespace),
        getTooltip: t => t.namespace
    };


    var f: { [ek: number]: string } = {};

    f[EntityKind.SystemString] = "#8c564b";
    f[EntityKind.System] = "#7f7f7f";
    f[EntityKind.Relational] = "#17becf";
    f[EntityKind.String] = "#e377c2";
    f[EntityKind.Shared] = "#2ca02c";
    f[EntityKind.Main] = "#d62728";
    f[EntityKind.Part] = "#ff7f0e";
    f[EntityKind.SharedPart] = "#bcbd22";

    var entityKind: ClientColorProvider = {
        name: "entityKind",
        getFill: t => f[t.entityKind],
        getTooltip: t => EntityKind[t.entityKind]
    };


    var entityData: ClientColorProvider = {
        name: "entityData",
        getFill: t => t.entityData == EntityData.Master ? "#2ca02c" :
            t.entityData == EntityData.Transactional ? "#d62728" : "black",
        getTooltip: t => EntityData[t.entityData]
    };

    var rowsColor = colorScaleSqr(info.tables.map(a => a.rows).max());
    var rows: ClientColorProvider = {
        name: "rows",
        getFill: t => <any>rowsColor(t.rows),
        getTooltip: t => t.rows + " " + MapMessage.Rows.niceToString()
    };

    var columnsColor = colorScaleSqr(info.tables.map(a => a.columns).max());
    var columns: ClientColorProvider = {
        name: "columns",
        getFill: t => <any>columnsColor(t.columns),
        getTooltip: t => t.columns + " " + MapMessage.Columns.niceToString()
    };

    var tableSizeColor = colorScaleSqr(info.tables.map(a => a.total_size_kb).max());
    var tableSize: ClientColorProvider = {
        name: "tableSize",
        getFill: t => <any>tableSizeColor(t.total_size_kb),
        getTooltip: t => t.total_size_kb + " KB"
    };


    return [namespace, entityKind, entityData, rows, columns, tableSize];
}
