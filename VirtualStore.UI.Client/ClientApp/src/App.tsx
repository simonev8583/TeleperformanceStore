import Layout from "./components/Layout";
import Home from "./pages/Home";
import { Route } from "react-router";
import * as React from "react";

import "./custom.css";
import ProductListPage from "./pages/product/ProductList";
import RegisterPage from "./pages/security/RegisterPage";
import ProductPage from "./pages/product/ProductPage";
import LoginPage from "./pages/security/LoginPage";
import { useSecurity } from "./hooks/useSecurity";

export default () => {
  const { userInSession } = useSecurity();

  if (!userInSession) {
    return (
      <>
        <Route exact path="/" component={LoginPage} />
        <Route exact path="/register" component={RegisterPage} />
      </>
    );
  }

  return (
    <Layout>
      <Route exact path="/" component={Home} />
      <Route exact path="/products" component={ProductListPage} />
      <Route exact path="/products/create" component={ProductPage} />
      <Route exact path="/products/edit/:id" component={ProductPage} />
    </Layout>
  );
};
