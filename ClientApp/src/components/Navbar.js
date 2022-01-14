import React from "react";
import { NavLink } from "react-router-dom";

export default function Navbar() {
	return (
		<div className="nav">
			<NavLink activeClassName="active" to="/" exact>
				Converter
			</NavLink>
			<NavLink activeClassName="active" to="/history">
				History
			</NavLink>
		</div>
	);
}
