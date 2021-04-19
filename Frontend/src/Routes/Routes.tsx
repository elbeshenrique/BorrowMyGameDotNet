import React from "react";
import { Route } from "react-router-dom";
import Friends from "../Pages/Friends";
import Games from "../Pages/Games";

function Routes(): JSX.Element {
    return (
        <>
            <Route path="/games" component={Games} />
            <Route path="/friends" component={Friends} />
        </>
    );
}

export default Routes;