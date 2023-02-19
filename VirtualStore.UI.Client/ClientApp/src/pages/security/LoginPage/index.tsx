import React, { ChangeEvent, Fragment, useState } from "react";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardTitle,
  Input,
  Label,
} from "reactstrap";
import { useSecurity } from "../../../hooks/useSecurity";
import { Credentials } from "../../../models/security/credentials.model";
import { Link } from "react-router-dom";

const LoginPage = () => {
  const { authenticate } = useSecurity();

  const [username, setUsername] = useState<string>("");
  const [usernameError, setUsernameError] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [passwordError, setPasswordError] = useState<string>("");

  const onChangeUsername = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setUsername(value);

    if (!value) {
      setUsernameError("El campo no puede estar vacio!");
      return;
    }

    setUsernameError("");
  };

  const onChangePassword = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;

    setPassword(value);

    if (!value) {
      setPasswordError("El campo no puede estar vacio!");
      return;
    }

    setPasswordError("");
  };

  const onSubmit = () => {
    authenticate({
      username,
      password,
    } as Credentials);
  };

  return (
    <Fragment>
      <Card
        style={{
          marginTop: 100,
          textAlign: "center",
          alignContent: "center",
          border: 1,
          borderColor: "#ccc",
        }}
      >
        <CardTitle>
          <h1>Iniciar sesion</h1>
        </CardTitle>
        <CardBody
          style={{
            border: 1,
            backgroundColor: "#ccc",
          }}
        >
          <div className="row col-12">
            <div className="formInput col-6">
              <Label>Nombre de usuario</Label>
              <Input
                name="username"
                placeholder="Ingresa el usuario"
                value={username}
                onChange={onChangeUsername}
              />
              {usernameError && (
                <span style={{ color: "red" }}>{usernameError}</span>
              )}
            </div>
            <div className="formInput col-6">
              <Label>Contraseña</Label>
              <Input
                name="password"
                type="password"
                placeholder="Ingresa la contrasela"
                value={password}
                onChange={onChangePassword}
              />
              {passwordError && (
                <span style={{ color: "red" }}>{passwordError}</span>
              )}
            </div>
          </div>
        </CardBody>
        <CardFooter>
          <div className="row col-12">
            <div className="col-9">
              <Button
                color="primary"
                disabled={!!usernameError || !!passwordError}
                onClick={onSubmit}
              >
                Log in
              </Button>
            </div>
            <Link to="/register">
              ¿No tienes cuenta?, clic para registrarse
            </Link>
          </div>
        </CardFooter>
      </Card>
    </Fragment>
  );
};

export default LoginPage;
