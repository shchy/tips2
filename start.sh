
MIGRATION_TAG=$1
WEBAPP_PATH="src/TipsWeb"
MIGRATIONS_PATH="${WEBAPP_PATH}/Migrations"
FINDED=0

for FILE in `find ${MIGRATIONS_PATH}/*${MIGRATION_TAG}.cs -type f`
do
    #Some function on the file
    FINDED=1
done

if [ $FINDED = 1 ]; then
    echo "Already Exists Migrations"
else
    dnx -p ${WEBAPP_PATH}/project.json ef migrations add ${MIGRATION_TAG}
    dnx -p ${WEBAPP_PATH}/project.json ef database update
fi

dnx -p ${WEBAPP_PATH}/project.json web
