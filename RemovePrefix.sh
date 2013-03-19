#!/bin/bash

# Prefix all .cs and .cs.meta files with XCE_

SCRIPT_PATH="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

for file in "$SCRIPT_PATH"/*; do
	if [[ $file == *.cs ]] && [[ $file == */XCE_*.cs ]]; then
		file="${file##*/}"
		echo "Renaming ${file} to ${file#XCE_}"
		mv ${file} ${file#XCE_}
	fi
	if [[ $file == *.cs.meta ]] && [[ $file == */XCE_*.cs.meta ]]; then
		file="${file##*/}"
		echo "Renaming ${file} to ${file#XCE_}"
		mv ${file} ${file#XCE_}	
	fi	
done