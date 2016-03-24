
MIGRATION_TAG=$1
WEBAPP_PATH="src/TipsWeb"
MIGRATIONS_PATH="${WEBAPP_PATH}/Migrations"


if [ -f "${MIGRATIONS_PATH}/${MIGRATION_TAG}.cs" ]; then
  echo "Already Exists Migrations"
else
    dnx -p ${WEBAPP_PATH}/project.json ef migrations add ${MIGRATION_TAG}
    dnx -p ${WEBAPP_PATH}/project.json ef database update
fi
dnx -p ${WEBAPP_PATH}/project.json web
