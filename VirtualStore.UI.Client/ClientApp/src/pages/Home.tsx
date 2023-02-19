import {
  Alert,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardTitle,
} from "reactstrap";
import React, { Fragment, useEffect, useState } from "react";
import { Product } from "../models/product/product.model";
import { useProduct } from "../hooks/useProduct";
import { Cart } from "../models/cart/cart.model";
import { useCart } from "../hooks/useCart";
import CartPage from "./cart";

const Home = () => {
  const { getProducts, products } = useProduct();
  const { cart, updateCart, getCart } = useCart();

  const [message, setMessage] = useState<string>("");

  useEffect(() => {
    getCart();
    getProducts();
  }, []);

  const addCart = (product: Product) => {
    let cartCloned: Cart = JSON.parse(JSON.stringify(cart));

    const filter = cartCloned.products.filter((p) => p.id === product.id)[0];

    if (filter) {
      if (filter.quantity + 1 > product.stock) {
        setMessage("No hay suficientes cantidades disponibles para agregar");

        setTimeout(() => {
          setMessage("");
        }, 2000);

        return;
      }
      filter.quantity += 1;
      updateCart(cartCloned);
      return;
    }

    product.quantity = 1;
    cartCloned.products.push(product);
    updateCart(cartCloned);
  };

  return (
    <Fragment>
      {message && <Alert color="warning">{message}</Alert>}
      <div className="row">
        <div className="row col-7">
          {products.length > 0 &&
            products.map((product) => (
              <Card className="col-4" style={{ margin: 10 }} key={product.id}>
                <CardBody>
                  <CardTitle>
                    <h3>{product.title}</h3>
                  </CardTitle>
                  <div className="row">
                    <div>{product.description} description of product</div>
                  </div>
                  <div className="row">
                    Precio:{" "}
                    <span style={{ color: "#4b4b4b" }}>${product.price}</span>
                  </div>
                  <div className="row">
                    Cantidades disponibles:
                    <span style={{ color: "#4b4b4b" }}>{product.stock}</span>
                  </div>
                </CardBody>
                <CardFooter>
                  <Button color="info" onClick={() => addCart(product)}>
                    Agregar al carro
                  </Button>
                </CardFooter>
              </Card>
            ))}
        </div>
        <div className="col-5">
          <CartPage cart={cart} />
        </div>
      </div>
    </Fragment>
  );
};

export default Home;
