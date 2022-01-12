import React from "react";
import { Currencies } from "../Currencies";

export default function Converter() {
	return (
		<div className="converter">
			<form>
				<div>
					<label>From </label>
					<select name="" id="" className="" onChange={() => console.log("hi")}>
						<option value="0">Select Currency</option>
						{Currencies.map((c, id) => (
							<option key={id} value={c.trim()}>
								{c.trim()}
							</option>
						))}
					</select>
					<input type="text" />
				</div>
				<div>
					<label>To</label>
					<select name="" id="" className="" onChange={() => console.log("hi")}>
						<option value="0">Select Currency</option>
						{Currencies.map((c, id) => (
							<option key={id} value={c.trim()}>
								{c.trim()}
							</option>
						))}
					</select>

					<input type="text" value="output" />
				</div>
				<button type="submit">Convert</button>
			</form>
		</div>
	);
}
