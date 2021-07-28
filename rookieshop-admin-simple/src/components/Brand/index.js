import React, { lazy } from 'react';
import { Route, Switch } from 'react-router-dom';

import { CREATE_BRAND, BRAND, EDIT_BRAND } from '../../Constants/pages';

const CreateBrand = lazy(() => import("./Create"));
const ListBrand = lazy(() => import("./List"));
const UpdateBrand = lazy(() => import("./Update"))

const Brand = () => {
    return (
        <Switch>
            <Route exact path={BRAND}>
                <ListBrand />
            </Route>
            <Route exact path={CREATE_BRAND}>
                <CreateBrand />
            </Route>
            <Route exact path={EDIT_BRAND}>
                <UpdateBrand />
            </Route>
        </Switch>
    )
};

export default Brand;