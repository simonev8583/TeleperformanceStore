import React, { Fragment, useEffect, useRef, useState } from "react";
import { useProduct } from "../../../hooks/useProduct";
import { Button, Table, Input } from "reactstrap";
import { Link } from "react-router-dom";

const ProductListPage = () => {
  const { productsOwn, getProductsOwn, removeProduct, uploadFile } =
    useProduct();

  const [productId, setProductId] = useState<string>("");

  const inputRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    getProductsOwn();
  }, []);

  const deleteProduct = (id: string) => {
    removeProduct(id);

    setTimeout(() => {
      getProductsOwn();
    }, 1000);
  };

  const insertFile = (event: any) => {
    const loadedFiles: File[] = Array.from(event.target.files);

    uploadFile(loadedFiles[0], productId);
  };

  const clickInputRef = (id: string) => {
    setProductId(id);
    inputRef.current!.click();
  };

  return (
    <Fragment>
      <input
        accept="image/png, image/jpeg"
        id="product-file"
        name="product-file"
        type="file"
        ref={inputRef}
        multiple
        style={{ display: "none" }}
        onChange={insertFile}
      />
      <div>
        <Link to="products/create" className="btn btn-primary">
          Agregar producto
        </Link>
      </div>
      <Table>
        <thead>
          <tr>
            <th>Titulo</th>
            <th>Descripción</th>
            <th>Precio</th>
            <th>Stock</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {productsOwn.map((product) => (
            <tr key={product.id}>
              <td>{product.title}</td>
              <td>{product.description}</td>
              <td>{product.price}</td>
              <td>{product.stock}</td>
              <td>
                <Link
                  to={`products/edit/${product.id}`}
                  className="btn btn-primary"
                >
                  Editar
                </Link>{" "}
                <Button
                  color="warning"
                  onClick={() => deleteProduct(product.id)}
                >
                  Eliminar
                </Button>{" "}
                <Button color="info" onClick={() => clickInputRef(product.id)}>
                  Subir imagen
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </Fragment>
  );
};

export default ProductListPage;
