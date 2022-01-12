import React from "react";
import Converter from "./components/Converter";
import History from "./components/History";
import Navbar from "./components/Navbar";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

export default function App() {
	return (
		<Router>
			<Navbar />
			<Switch>
				<Route path="/history">
					<History />
				</Route>
				<Route path="/">
					<Converter />
				</Route>
			</Switch>
		</Router>
	);
}
