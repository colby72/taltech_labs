#!/bin/bash
SCRIPT_FILE="new_script.sh"

cat > ${SCRIPT_FILE} << NEW_SCRIPT_SRC
#!/bin/bash
echo Hello World from another script!

NEW_SCRIPT_SRC

if [[ -e ${SCRIPT_FILE} ]]; then
	chmod 700 ${SCRIPT_FILE}
	chown root:root ${SCRIPT_FILE}
	echo Done
else
	echo Failed to create ${SCRIPT_FILE}
	echo Done
fi
