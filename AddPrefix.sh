#!/bin/bash

# Prefix all .cs and .cs.meta files with XCE_

SCRIPT_PATH="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

for file in "$SCRIPT_PATH"/*; do
	if [[ $file == *.cs ]] && [[ $file != */XCE_*.cs ]]; then
		echo  "Renaming ${file##*/} to XCE_${file##*/}"
		mv ${file##*/} XCE_${file##*/}
		#mv $file 
	fi
	if [[ $file == *.cs.meta ]] && [[ $file != */XCE_*.cs.meta ]]; then
		echo  "Renaming ${file##*/} to XCE_${file##*/}"
		mv ${file##*/} XCE_${file##*/}
	fi	
done